<template>
  <li>
    <BaseCard>
      <header>
        <h3>{{title}}</h3>
        <BaseButton
          @click="deleteResource(id)"
          mode="flat">Delete</BaseButton>
      </header>

    <p>{{description}}</p>
    <nav>
      <a :href="link">View Resource</a>
    </nav>
    </BaseCard>
  </li>
</template>

<script>
  import BaseCard from "@/assignments/MyResources/components/UI/BaseCard.vue";
  import BaseButton from "@/assignments/MyResources/components/UI/BaseButton.vue";
  export default {
    name: "LearningResource",
    components: {BaseButton, BaseCard},
    props: [
      'id',
      'title',
      'description',
      'link'
    ],
    inject:['deleteResource']
  }
</script>

<style scoped>
  li {
    margin: auto;
    max-width: 40rem;
  }

  header {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  h3 {
    font-size: 1.25rem;
    margin: 0.5rem 0;
  }

  p {
    margin: 0.5rem 0;
  }

  a {
    text-decoration: none;
    color: #ce5c00;
  }

  a:hover,
  a:active {
    color: #c89300;
  }
</style>
