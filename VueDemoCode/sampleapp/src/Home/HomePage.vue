<template>
  <div class="home">
   <div>
     <img class="logo" src="../assets/CCC_logo.1.png" aria-hidden="true"/>
   </div>
   <div class="get-started">
   Hello World Orlando Code Camp
  </div>
  </div>
</template>

<script>
export default {
  name: 'HomePage',
  props: {
    msg: String,
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
