<template>
	<Page class="page">
		<ActionBar title="Camera" class="action-bar" />
        <StackLayout>
            <Button text="Home" class="btn btn-primary" marginTop="20" @tap="navigateHome"></Button>
        </StackLayout>
        <ScrollView>
        <StackLayout>
            <Button :text="textPicture" class="btn btn-primary" marginTop="20" @tap="takePicture"></Button>
            <Image :src="pictureFromCamera"/>
            <Button text="Axios Take Picture" @tap="takeAxiosPicture" />
            <Image :src="pictureAxios"/>
            
        </StackLayout>
        </ScrollView>
	</Page>
</template>


<script>
import * as camera from "nativescript-camera";
import * as http from "http";
import * as imageSource from "tns-core-modules/image-source";
import * as axios from "axios/dist/axios";
import App from '../components/App';
const Vue = require('nativescript-vue');

export default {
    data() {
        return {
            pictureFromCamera: null,
            textPicture: "Take a Picture",
            pictureBase64String : null,
            pictureAxios : null
        };
    },
    methods: {
        navigateHome()
        {
          this.$navigateTo(App);
        },
        takePicture() {
            // See the options at https://github.com/NativeScript/nativescript-camera#using-the-options-to-take-memory-efficient-picture
            // for more information on how to customize the pictures you take.
            camera.requestPermissions();
            camera                
                .takePicture({ width: 300, height: 300, keepAspectRatio: true })
                .then(imageAsset => {
                    this.pictureFromCamera = imageAsset;

                    let source = new imageSource.ImageSource();
                    source.fromAsset(imageAsset).then(source => {
                        this.pictureBase64String = source.toBase64String("jpg",60);
                        console.log(this.pictureBase64String);
                    });

                    http.request({
                                  url: "https://testbskazure.azurewebsites.net/api/Function1",
                                  method: "POST",
                                  headers: { "Content-Type": "application/json" },
                                  content: JSON.stringify({
                                           ImageContent: this.pictureBase64String.toString()     
                                           })
                                 }).then(response => {
                                     var result = response.content.toJSON();
                                     console.log(result);
                                 }, error => {
                                    console.error(error);
                                 });
                })
                .catch(err => {
                    console.log("Error -> " + err.message);
                });
        },
        takeAxiosPicture(){
            // See the options at https://github.com/NativeScript/nativescript-camera#using-the-options-to-take-memory-efficient-picture
            // for more information on how to customize the pictures you take.
            camera.requestPermissions();
            camera                
                .takePicture({ width: 300, height: 300, keepAspectRatio: true })
                .then(imageAsset => {
                    this.pictureAxios = imageAsset;

                    let source = new imageSource.ImageSource();
                    source.fromAsset(imageAsset).then(source => {
                        this.pictureBase64String = source.toBase64String("jpg",60);
                        console.log(this.pictureBase64String);
                    });
                    
                    
                    axios({
                            method: "post",
                            url: "https://testbskazure.azurewebsites.net/api/Function1",
                            data: {
                                           ImageContent: this.pictureBase64String.toString()   
                                           },
                            headers : {"Content-Type":"application/json"}      
                          })
                    .then(response => {
                                     var result = response.data;
                                     console.log(result);
                                 }, error => {
                                    console.error(error);
                                 });
                })    
        },  
    }
};
</script>
