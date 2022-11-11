<template>
  <div id="app">
    <h1 class="mainHeading">Movies review system</h1>
    <div v-for="product in products" :key="product.id" >
      <Product :productInfo="product" />
    </div>
  </div>
</template>

<script>
import Product from "./components/Product.vue";

export default {
  name: "App",
  components: {
    Product,
  },
  data() {
    return {
      products: [],
    };
  },
  methods: {
    getAllProducts() {
      this.axios
        .get("https://localhost:44350/api/Products")
        .then((response) => { 
          this.products = response.data; 
        })
        .catch((error) => {
          console.log(error);
        });
    },
    goToComment(){
      this.$router.push("/comments");
    }
  },
  created() {
    this.getAllProducts();
  },
};
</script>

<style>
body {
  background-color: #000000;
  margin: 0px;
  font-family: tahoma;
  color: #ffffff;
}

h1 {
  font-size: 50px;
  margin: 0;
}
.mainHeading{
  text-transform: uppercase;
  color: #fff;
  font-size: 90px;
  line-height: 98px;
  font-weight: 700;
  border: 4px solid #fff;
  padding: 12px;
  text-align: center;
}

input {
    width: 100%;
    height: 30px;
    margin-bottom: 20px;
    border: none;
    border-bottom: 1px solid #000;
    outline: none;
}
input[type="submit"]{
  border: 1px solid #000;
  margin: 15px 0;
}
label {
  font-size: 20px;
  margin-bottom: 5px;
}

p {
  font-size: 16px;
  line-height: 24px;
}
.review-form {
  display: flex;
  flex-direction: column;
  width: 425px;
  padding: 20px;
  margin: 40px;
  border: 2px solid #d8d8d8;
  background-color: white;
  -webkit-box-shadow: 0px 2px 15px -12px rgba(0, 0, 0, 0.57);
  -moz-box-shadow: 0px 2px 15px -12px rgba(0, 0, 0, 0.57);
  box-shadow: 2px 15px -12px rgba(0, 0, 0, 0.57);
}

select {
  height: 40px;
  font-size: 20px;
  background-color: white;
  cursor: pointer;
}

textarea {
  width: 95%;
  height: 70px;
  padding: 10px;
  font-size: 20px;
  margin-bottom: 20px;
}

ul {
  list-style-type: none;
}
#app{
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}
#app>div {
  flex: 1 0 50%;
}

.product-image img{
  object-fit: cover;
  width: 100%;
  height: 450px;
}
.product-info {
  padding: 20px;
  margin-top: 10px;
  flex-basis: 500px;
  border: 2px solid #fff;
  transition: .5s;
}
.product h1{
  text-transform: capitalize;
}
.disabledButton {
  background-color: #d8d8d8;
}
div#form-review {
    display: flex;
    justify-content: center;
}
button{
  outline: none;
  border: 1px solid #fff;
  background: #fff;
  color: #000;
  padding: 12px;
  position: relative;
  cursor: pointer;
}
button::before{
  content: "";
  position: absolute;
  height: calc(100% + 10px);
  width: 1px;
  background: #fff;
  bottom:-10px;
  right: -5px;
}
button::after{
  content: "";
  position: absolute;
  width: calc(100% + 10px);
  height: 1px;
  background: #fff;
  bottom: -5px;
  right: -10px;
}
button,button::before,button::after{
  transition: .5s;
}
button:hover::before,button:hover::after{
  height: 0px;
  width: 0px;
}
button:hover{
  background: rgba(255,255,255,0.5);
}
.product:hover .product-info{
  transform: translateY(-15px);
}
</style>
