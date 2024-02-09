<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios'
import { RouterLink } from 'vue-router';
import ConfirmDeletePopup from '@/components/ConfirmDeletePopup.vue';

const beachCollection = ref([]);

const deleteItemId = ref(0);

let deleteModalInstance;

onMounted(()=> {
    deleteModalInstance = new window.bootstrap.Modal(document.getElementById('deletePopup'));
    axios.get("http://localhost:5138/Beach")
        .then((response) => {
            beachCollection.value = response.data;
        })
})

const openDeleteModal = (id) => {
    deleteItemId.value = id;
    deleteModalInstance.show();
}

const confirmDelete = () => {
    axios.delete(`http://localhost:5138/Beach/${deleteItemId.value}`)
    .then(() => {
        beachCollection.value = beachCollection.value.filter(_ => _.id !== deleteItemId.value);
        deleteModalInstance.hide();
    })
}

</script>
<template>
    <div class="container">
        <div class="row mt-2">
            <div class="col col-md-4 offset-md-4 mb-3">
                <RouterLink class="btn btn-primary" to="/add">Add</RouterLink>
            </div>
        </div>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <div class="col" v-for="item in beachCollection" :key="item.id">
                <div class="card">
                    <img :src="item.imageUrl" class="card-img-top" alt="..." style="height: 250px">
                    <div class="card-body">
                        <h5 class="card-title">{{ item.beachName}}</h5>
                        <p class="card-text">Location - {{ item.place }}</p>
                        <RouterLink class="btn btn-primary me-2" :to="`/edit/${item.id}`">Edit</RouterLink>
                        <button type="button" @click="$event => openDeleteModal(item.id)" class="btn btn-danger">Delete</button>
                    </div>
                </div>
            </div>
        </div>
        <ConfirmDeletePopup @confirm-delete-click="confirmDelete"></ConfirmDeletePopup>
    </div>
</template>
<style>

</style>