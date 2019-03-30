import Vue from 'nativescript-vue';
import Vuex from 'vuex';
Vue.use(Vuex);

const appstore = new Vuex.Store({
    state: {
            counter: 0,
            
    },
    mutations: {
        addCounter(state) {
            state.counter++;
        },
		
        decreaseCounter(state) {
           state.counter--;
        },	
       
    }
});

export default appstore;