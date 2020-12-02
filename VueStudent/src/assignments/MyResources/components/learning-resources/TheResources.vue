<template>
  <BaseCard>
    <BaseButton
      @click="setSelectedTab('stored-resources')"
      :mode="storedResButtonMode"
    >
      Stored Resources
    </BaseButton>
    <BaseButton
      @click="setSelectedTab('add-resource')"
      :mode="addResButtonMode"
    >
      Add Resource
    </BaseButton>
  </BaseCard>
  <keep-alive>
    <component :is="selectedTab"></component>
  </keep-alive>
</template>

<script>
  import BaseCard from "../UI/BaseCard.vue";
  import BaseButton from "../UI/BaseButton.vue";
  import StoredResources from "./StoredResources.vue";
  import AddResource from "./AddResource.vue";

  export default {
    name: "TheResources",
    components: {
      BaseButton,
      BaseCard,
      StoredResources,
      AddResource
    },
    data() {
      return {
        selectedTab: 'add-resource',
        storedResources: [
          {
            id: '1',
            title: 'title1',
            description: 'd1',
            link: 'https://www.google.com/'
          },
          {
            id: '2',
            title: 'title2',
            description: 'd2',
            link: 'https://www.google.com/'
          }
        ]
      };
    },
    provide() {
      return {
        resources: this.storedResources,
        addResource: this.addResource,
        deleteResource: this.removeResource
      }
    },
    computed: {
      storedResButtonMode() {
        return this.selectedTab === 'stored-resources' ? null : 'flat';
      },
      addResButtonMode() {
        return this.selectedTab === 'add-resource' ? null : 'flat';
      }
    },
    methods: {
      setSelectedTab(tab) {
        this.selectedTab = tab;
      },
      addResource(title, description, url) {
        const newResource = {
          id: new Date().toISOString(),
          title: title,
          description: description,
          link: url
        };
        this.storedResources.unshift(newResource);
        this.selectedTab = 'stored-resources';
      },
      removeResource(resId) {
        const resIndex = this.storedResources.findIndex(
          res=>res.id===resId
        );
        this.storedResources.splice(resIndex, 1);
      }
    }
  }
</script>

<style scoped>

</style>
