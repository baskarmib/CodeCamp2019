<template>
  <div class="home">
   <div>
     <img class="logo" src="../assets/CCC_logo.1.png" aria-hidden="true"/>
   </div>
   <div class="get-started">
   Logged Out
  </div>
  </div>
</template>

<script>

import auth from '../Auth/AuthService';

export default {
  name: 'Logout',
  props: {
    msg: String,
  },
  created() {
    auth.logOut();
    console.log('Logged Out');
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.home
{
  text-align: center;
}
.logo
{
  height: 300px;
}
</style>
