import { ADD_TO_CART, REMOVE_FROM_CART } from "../actions/cartActions";
import { cartItems } from "../initialValues/cartItems";

const initialState = {
  cartItems: cartItems,
};

export default function cartReducer(state = initialState, { type, Load }) {
  switch (type) {
    case ADD_TO_CART:
      let product = state.cartItems.find((i) => i.product.id === Load.id);
      if (product) {
        product.amount++;
        return {
          ...state,
        };
      } else {
        return {
          ...state,
          cartItems: [...state.cartItems, { amount: 1, product: Load }],
        };
      }

    case REMOVE_FROM_CART:
      return {
        ...state,
        cartItems: state.cartItems.filter((i) => i.product.id !== Load.id),
      };
    default:
      return state;
  }
}