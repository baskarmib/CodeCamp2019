<template>
  <div class="home">
   <div>
     <img class="logo" src="../assets/novacode.png" aria-hidden="true"/>
   </div>
   <div class="get-started">
   Hello World NoVA Code Camp
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
