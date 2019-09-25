<template>
  <div id="app" class="main-wrapper back-color">
    <app-header />
    <app-content />
    <app-footer />
    <app-progress v-if="isLoading" />
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
.main-wrapper {
  display: flex;
  flex-direction: column;
  min-height: 100%;
}
</style>
