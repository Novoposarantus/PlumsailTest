<template>
  <div id="app" class="main-wrapper">
    <app-header />
    <app-content />
    <app-footer />
    <app-progress v-show="isLoading" />
  </div>
</template>

<script>
import AppHeader from './components/layout/AppHeader';
import AppFooter from './components/layout/AppFooter';
import AppContent from './components/layout/AppContent';
import AppProgress from './components/layout/AppProgress';
import { mapGetters } from 'vuex';

export default {
  name: 'app',
  components:{
    AppHeader,
    AppFooter,
    AppContent,
    AppProgress
  },
  computed:{
    ...mapGetters({
      isLoading: "IS_LOADING"
    })
  }
}
</script>

<style>

html, body {
  height: 100%;
  width: 100%;
  padding: 0;
  margin: 0;
}

.main-wrapper {
  display: flex;
  flex-direction: column;
  height: 100%;
  background-color: #f0f8ff;
}
</style>
