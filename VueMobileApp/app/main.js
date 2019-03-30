import Vue from 'nativescript-vue'
import App from './components/App'
import VueDevtools from 'nativescript-vue-devtools'
import routes from "./router";
import Vuex from 'vuex';
import appstore from './store/appStore';
Vue.use(Vuex);

if(TNS_ENV !== 'production') {
  Vue.use(VueDevtools)
}
// Prints Vue logs when --env.production is *NOT* set while building
Vue.config.silent = (TNS_ENV === 'production')


new Vue({
  render: h => h('frame', [h(routes.home)]),
  store : appstore
}).$start()
