<template>
<div>
  <div class="top">
      <form id="search">
    Search <input name="query" v-model="searchQuery">
   </form>
   <div></div>
    </div>
    <div class="middle">
      <SessionList :filterKey="searchQuery" :columns="gridColumns" :data="gridData" />
    </div>
</div>
</template>
<script>
import SessionList from '../Sessions/SessionList.vue';
import sessions from '../data/sessionlist';
import auth from '../Auth/AuthService';

export default {
  name: 'SessionPage',
  components: {
    SessionList,
  },
  data() {
    return {
      searchQuery: '',
      gridColumns: ['sessionTime', 'room', 'sessionBy', 'description'],
      gridData: sessions,
      isauthenticated: '',
    };
  },
  mounted() {
    this.isauthenticated = auth.isAuthenticated();
    this.$emit('displaylink', this.isauthenticated);
  },
};

</script>
<style>

body {
  font-family: Helvetica Neue, Arial, sans-serif;
  font-size: 14px;
  color: #444;
}

table {
  border: 2px solid #42b983;
  border-radius: 3px;
  background-color: #fff;
}

th {
  background-color: #42b983;
  color: rgba(255,255,255,0.66);
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

td {
  background-color: #f9f9f9;
}

th, td {
  min-width: 120px;
  padding: 10px 20px;
}

th.active {
  color: #fff;
}

.top{

  vertical-align: top;
}

.middle{

  vertical-align: middle;

}

</style>
