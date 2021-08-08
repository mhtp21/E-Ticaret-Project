import React, {useState} from 'react';
import CartSummary from './CartSummary';
import { Container, Menu,Input } from 'semantic-ui-react';
import SignedOut from "./SignedOut";
import SignedIn from "./SignedIn";
import { useHistory } from "react-router";
import { useSelector } from 'react-redux';

const colors = ['blue']

  
export default function Navi() {
    const {cartItems} = useSelector(state => state.cart)
    const [isAuthenticated, setisAuthenticated] = useState(true)
    const history = useHistory()
    function handleSignOut() {
        setisAuthenticated(false)
        history.push("/")
      }
      function handleSignIn() { 
          setisAuthenticated(true)
       }
    return (
        <div>
            <Menu color={colors} fixed="top">
        <Container>
          <Menu.Item name="Anasayfa" />
          <Menu.Item>
          <Input icon='search' placeholder='Ara...' />
          </Menu.Item>
          

          <Menu.Menu position="right">
            {cartItems.length>0&&<CartSummary/>}
            {isAuthenticated?<SignedIn signOut={handleSignOut} />
            :<SignedOut signIn={handleSignIn}/>}  
          </Menu.Menu>
        </Container>
      </Menu>
        </div>
    )
}

