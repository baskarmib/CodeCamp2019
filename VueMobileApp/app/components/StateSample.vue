<template>
	<Page class="page">
		<ActionBar title="State Sample" class="action-bar" />
       
        <ScrollView>
        <StackLayout>
           <Button text="Home" class="btn btn-primary" marginTop="20" @tap="navigateHome"></Button>
            <Button text="IncreaseCounter" class="btn btn-primary" marginTop="40" @tap="increaseCounter"></Button>
            <Label :text="getCounter" />    
        </StackLayout>
        </ScrollView>
	</Page>
</template>


<script>

import App from '../components/App';
const Vue = require('nativescript-vue');

export default {
    
    methods: {
        navigateHome()
        {
          this.$navigateTo(App);
        },
        increaseCounter()
		{
		  this.$store.commit("addCounter");
		}          
    },
    computed:
    {
        getCounter()
        {
          console.log(this.$store.state.counter);
          return this.$store.state.counter;
        }
    }
};
</script>
