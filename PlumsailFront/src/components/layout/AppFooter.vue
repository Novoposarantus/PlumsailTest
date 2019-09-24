<template>
    <div class="wrapper">
      <div>
        <a href="https://github.com/Novoposarantus/PlumsailTest" target="_blank" class="icon">
          <img class="icon" src="../../../public/github.png" />
        </a>
      </div>
      <div>
        <div>Контакты:</div>
        <div class="link-wrapper">
          <a href="mailto: novoposarantu1@gmail.com" class="link">
            novoposarantu1@gmail.com
          </a>
        </div>
        <div class="link-wrapper">
          <a href="tel:+79531801740" class="link">
            +79531801740
          </a>
        </div>
      </div>
    </div>
</template>


<style scoped>
.wrapper {
  flex: 0 0 auto;
  width: 800px;
  max-width: 100%;
  margin: 0 auto;
  border-top: 1px solid rgb(210,210,215);
  padding: 5px 10px 10px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  box-sizing: border-box;
}

.icon {
  height: 36px;
}

.link {
  text-decoration: none;
  border-bottom: 1px solid transparent;
  color: black;
  cursor: pointer;
  font-size: 16px;
  transition: all linear .3s;
}

.link:hover {
  border-color: black;
}

.link-wrapper{
  height: 18px;
  margin-top: 7px;
}
</style>
