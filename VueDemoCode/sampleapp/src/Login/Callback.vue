<template>
<div>
</div>
</template>

<script>

import auth from '../Auth/AuthService';

export default {
  name: 'Callback',
  methods: {
    handleLoginEvent(data) {
      this.$router.push(data.state.target || '/');
    },
  },
  created() {
    auth.handleAuthentication();
    this.isauthenticated = auth.isAuthenticated();
    this.$emit('displaylink', this.isauthenticated);
  },
  mounted() {
    this.isauthenticated = auth.isAuthenticated();
    this.$emit('displaylink', this.isauthenticated);
  },
};
</script>

<style scoped>

</style>
