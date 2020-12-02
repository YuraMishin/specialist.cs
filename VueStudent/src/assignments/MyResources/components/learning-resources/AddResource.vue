<template>
  <BaseDialog
    @close="confirmError"
    title="Invalid Input"
    v-if="inputIsInvalid">
    <template #default>
      <p>Unfortunately, wrong credentials!</p>
    </template>
    <template #actions>
      <BaseButton @click="confirmError">OK</BaseButton>
    </template>
  </BaseDialog>
  <h2>Add Resource</h2>
  <BaseCard>
    <form @submit.prevent="submitData">
      <div class="form-control">
        <label for="title">Title</label>
        <input type="text"
               id="title"
               name="title"
               ref="titleInput"
        >
      </div>
      <div class="form-control">
        <label for="description">Description</label>
        <textarea id="description"
                  name="description"
                  rows="3"
                  ref="descInput"
        >
                  </textarea>
      </div>
      <div class="form-control">
        <label for="link">Link</label>
        <input type="url"
               id="link"
               name="link"
               ref="linkInput"
        >
      </div>
      <div>
        <BaseButton type="submit">Add Resource</BaseButton>
      </div>
    </form>
  </BaseCard>
</template>

<script>
  import BaseCard from "@/assignments/MyResources/components/UI/BaseCard";
  import BaseButton from "@/assignments/MyResources/components/UI/BaseButton";
  import BaseDialog from "@/assignments/MyResources/components/UI/BaseDialog";

  export default {
    name: "AddResource",
    inject: ['addResource'],
    components: {BaseDialog, BaseButton, BaseCard},
    data() {
      return {
        inputIsInvalid: false
      }
    },
    methods: {
      confirmError() {
        this.inputIsInvalid = false;
      },
      submitData() {
        const enteredTitle = this.$refs.titleInput.value;
        const enteredDescription = this.$refs.descInput.value;
        const enteredUrl = this.$refs.linkInput.value;

        const checkEnteredTitle = enteredTitle.trim() === '';
        const checkEnteredDescription = enteredDescription.trim() === '';
        const checkEnteredUrl = enteredUrl.trim() === '';

        if (checkEnteredTitle || checkEnteredDescription || checkEnteredUrl) {
          this.inputIsInvalid = true;
          return;
        }

        this.addResource(enteredTitle, enteredDescription, enteredUrl);
      }
    }
  }
</script>

<style scoped>
  label {
    font-weight: bold;
    display: block;
    margin-bottom: 0.5rem;
  }

  input,
  textarea {
    display: block;
    width: 100%;
    font: inherit;
    padding: 0.15rem;
    border: 1px solid #ccc;
  }

  input:focus,
  textarea:focus {
    outline: none;
    border-color: #3a0061;
    background-color: #f7ebff;
  }

  .form-control {
    margin: 1rem 0;
  }
</style>
