<template>
    <Page>
        <ActionBar title="Welcome to NativeScript-Vue!"/>
        <StackLayout>
            <Label class="message" :text="msg" col="0" row="0"/>
            <Button text="TakePicture" class="btn btn-primary" marginTop="20" @tap="navigate"></Button>
            <Button text="StateSample" class="btn btn-primary" marginTop="20" @tap="navigateState"></Button>
        </StackLayout>       
        
    </Page>
</template>

<script >
 import TakePicture from '../components/TakePicture';
 import StateSample from '../components/StateSample';
 const Vue = require('nativescript-vue');

 export default {
    data() {
      return {
        msg: 'Hello World!'
      }
    },
    methods: {
           navigate()
           {
             this.$navigateTo(TakePicture);
           },
           navigateState()
           {
               this.$navigateTo(StateSample);
           }
    }
  }
</script>

<style scoped>
    ActionBar {
        background-color: #53ba82;
        color: #ffffff;
    }

    .message {
        vertical-align: center;
        text-align: center;
        font-size: 20;
        color: #333333;
    }
</style>
