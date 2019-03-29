import Vue from 'vue';
import Router from 'vue-router';

import HomePage from '../Home/HomePage.vue';
import SessionsPage from '../Sessions/SessionPage.vue';
import Callback from '../Login/Callback.vue';
import auth from '../Auth/AuthService';
import Logout from '../Login/Logout.vue';

Vue.use(Router);

const router = new Router({
  mode: 'history',
  routes: [
    {
      name: 'Home',
      path: '',
      component: HomePage,
    },
    {
      name: 'Sessions',
      path: '/Sessions',
      component: SessionsPage,
    },
    {
      path: '/callback',
      name: 'Callback',
      component: Callback,
    },
    {
      path: '/logout',
      name: 'Logout',
      component: Logout,
    },
  ],
});

router.beforeEach((to, from, next) => {
  if (to.path === '/' || to.path === '/callback' || to.path === '/logout' || auth.isAuthenticated()) {
    return next();
  }

  return auth.login({ target: to.path });
});

export default router;
