import Vue from 'vue';
import App from './App.vue';

import router from './router';
import AuthPlugin from './plugins/auth';

Vue.config.productionTip = false;
Vue.use(AuthPlugin);
new Vue({
  render: h => h(App),
  router,
}).$mount('#app');
