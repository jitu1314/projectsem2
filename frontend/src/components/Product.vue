<template>
  <div class="main_block">
    <div class="bg" v-if="commentForm"></div>
    <div class="product">
      <div class="product-image">
        <img :src="productInfo.image" />
      </div>

      <div class="product-info">
        <h1>{{ productInfo.name }}</h1>
        <p>{{ productInfo.description }}</p>
        <p>Tickets Price: {{ productInfo.pricing }} $/seat</p>
        <div class="btns">
        <button v-on:click="addComment">Share review</button>
        </div>
      </div>
    </div>
    <div id="form-review" v-if="commentForm">
      <form class="review-form" @submit.prevent="onSubmit">
      <button class="close" v-on:click="closeComment">X</button>
        <h3>Leave a review</h3>
        <label for="name">Name:</label>
        <input type="text" id="name" v-model="name" required/>
        <input type="text" id="product_id" v-model="product_id" hidden />

        <label for="comment">Review:</label>
        <textarea id="comment" v-model="comment" required></textarea>

        <label for="rating">Rating:</label>
        <select id="rating" v-model.number="rating" required>
          <option>5</option>
          <option>4</option>
          <option>3</option>
          <option>2</option>
          <option>1</option>
        </select>

        <input class="button" type="submit" value="Submit" />
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "Product",
  props: {
    productInfo: Object,
  },
  data() {
    return {
      cart: 0,
      name: "",
      product_id: "",
      comment: "",
      rating: "",
      recommend: "",
      commentForm:false,
    };
  },
  methods: {
    addComment(){
      this.commentForm =true;
    },
    closeComment(){
      this.commentForm =false;
    },
    onSubmit() {
      this.axios
        .post("https://localhost:44350/api/Comments", {
          name: this.name,
          product_id: this.product_id,
          review: this.comment,
          rating: this.rating, 
        })
        .then((response) => {
          console.log(response.data);
          this.commentForm =false;
          alert("Thank you for sharing your review!!");
        })
        .catch((error) => {
          console.log(error);
        });
  },
  mounted() {
    this.product_id = this.productInfo.product_id;
  },
  }
};
</script>
 
<style scoped>
.product,.main_block{
  position: relative;
}
.bg{
  display: inline-block;
  height: 100%;
  width: 100%;
  position: absolute;
  top: 0;
  left: 0;
  background: rgba(0,0,0,0.5);
  z-index: 1;
}
.review-form{
  position: absolute;
  top: 0;
  left: 50%;
  transform: translateX(-50%);
  z-index: 2;
  color:#000;
  border-radius: 14px;
  margin-left:0;
  margin-right:0;
}
.close{
  position: absolute;
  top: 0;
  right: 0;
  display: inline-block;
  background: #fff;
  border: 2px solid #000;
  color: #000;
  margin: 0;
  padding: 0;
  width: 25px;
  border-radius: 100%;
  line-height: 20px;
  height: 25px;
  font-weight: 700;
}
.close::before,.close::after{
  content: "";
  display: none;
}
.product-info p{
    overflow: hidden;
    display: -webkit-box;
    -webkit-line-clamp: 2;
    -webkit-box-orient: vertical;
}
.product{
  justify-content: space-between;
  align-items: center;
  margin: 60px 15px;
}
.product-image{
  flex: 1;
  position: relative;
}

.btns{
  display: flex;
  justify-content: space-between;
}
.cart p{
  border: 1px solid #fff;
  padding: 15px;
  text-align: center;
}
</style>
