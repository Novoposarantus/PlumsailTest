<template>
  <div class="wrapper">
    <div class="content default-page-wrapper">
      <div class="header-text">Тестовое задание</div>
      <div class="nav">
        <router-link class="link" :to="{name: routes.createObject.name}">
          <link-text text="Создать" :icon="editIcon"/>
        </router-link>
        <router-link class="link" :to="{name: routes.list.name}">
          <link-text text="Список" :icon="listIcon"/>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import LinkText from './common/LinkText';
import listIcon from '../../../public/list.png';
import editIcon from '../../../public/edit.png';
import { routes } from '../../support';

export default {
  components:{
    LinkText
  },
  data(){
    return {
      routes,
      listIcon,
      editIcon
    }
  }
}
</script>

<style scoped>
.wrapper {
  display: flex;
  justify-content: center;
  flex: 0 0 auto;
  height: 50px;
  background: linear-gradient(to top, rgb(49, 49, 49) , rgb(20, 20, 20) , rgb(49, 49, 49) );
  box-sizing: border-box;
}

.content {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 10px;
}

.nav {
  display: flex;
}

.header-text{
  color: white;
  font-size: 25px;
}

.link {
  display: flex;
  align-items: center;
  text-decoration: none;
  color: white;
  cursor: pointer;
  transition: all linear .3s;
  font-size: 18px;
}

.router-link-active {
  color: rgb(185, 185, 185);
}

.link:not(:first-child){
  margin-left: 15px;
}

.link:hover {
  color: rgb(185, 185, 185);
}

</style>
