<script setup>
import axios from 'axios';
import { onMounted, reactive } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute();
const router = useRouter();

let beachToUpdate = reactive({
    id : 0,
    beachName: "",
    place: "",
    imageUrl: ""
});

const updateBeach = () => {
    axios.put("http://localhost:5138/Beach", beachToUpdate)
        .then(() => {
            router.push("/");
        })
}


onMounted(() => {
    axios.get(`http://localhost:5138/Beach/${route.params.id}`)
        .then((response) => {
            beachToUpdate.beachName = response.data.beachName;
            beachToUpdate.imageUrl = response.data.imageUrl;
            beachToUpdate.place = response.data.place;
            beachToUpdate.id = response.data.id;
        })
})


</script>

<template>
    <div class="container mt-4">
        <form @submit.prevent="updateBeach">
            <legend>Update A New Item</legend>
            <div class="mb-3">
                <label for="txtBeachName" class="form-label">Beach Name</label>
                <input 
                    type="text" 
                    class="form-control" 
                    id="txtBeachName" 
                    aria-describedby="emailHelp"
                    v-model="beachToUpdate.beachName">
            </div>
            <div class="mb-3">
                <label for="txtLocation" class="form-label">Location</label>
                <input 
                    type="text" 
                    class="form-control" 
                    id="txtLocation" 
                    aria-describedby="emailHelp"
                    v-model="beachToUpdate.place">
            </div>
            <div class="mb-3">
                <label for="txtImageUrl" class="form-label">ImageUrl</label>
                <input 
                    type="text" 
                    class="form-control" 
                    id="txtImageUrl" 
                    aria-describedby="emailHelp"
                    v-model="beachToUpdate.imageUrl">
            </div>
            <button type="submit" class="btn btn-primary">Update</button>
        </form>
    </div>
</template>