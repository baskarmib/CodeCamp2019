<template>
  <div id="app">
    <header>
<nav>
  <ul>
      <li class="nav-item">
      <router-link class="nav-link" :to="{name :'Home'}" exact>
      <img class="logo" src="./assets/logo.png"/>
      Home </router-link></li>
      <li class="nav-item">
       <router-link class="nav-link" :to="{name :'Sessions'}" exact>Sessions</router-link>
      </li>
      <li v-show="isauthenticated" class="nav-item">
       <router-link class="nav-link" :to="{name :'Logout'}" exact>Logout</router-link>
      </li>
  </ul>
</nav>
    </header>
    <main>
    <div id="demogrid">
    <router-view  v-on:displaylink="displaylogout"></router-view>
   </div>
    </main>
  </div>
</template>
<script>
// bootstrap the demo
import auth from './Auth/AuthService';

export default{
  name: 'App',
  data() {
    return { isauthenticated: '' };
  },
  mounted() {
    this.isauthenticated = auth.isAuthenticated();
    this.$emit('displaylink', this.isauthenticated);
  },
  methods: {
    displaylogout(first) {
      this.isauthenticated = first;
      console.log('event consumed');
    },
  },
};
</script>

<style>
body
{
  background :linear-gradient(to bottom,#555, #999 );
  background-attachment: fixed;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
}
main
{
margin:0 auto;
padding: 30px;
background-color: white;
width :1024px;
min-height: 300px;
}
header {
  background-color: #999;
  width: 1084px;
  margin: 0 auto;
}
ul {
  padding: 3px;
  display: flex;
}
.nav-item {
  display: inline-block;
  padding: 5px 10px;
  font-size: 22px;
  border-right: 1px solid #bbb;
}
.logo {
  vertical-align: middle;
  height: 30px;
}
.nav-link{
  text-decoration: none;
  color: inherit;
}
.router-link-active{
  color:white;
}
</style>
