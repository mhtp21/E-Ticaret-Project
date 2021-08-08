import React from 'react'
import { Button, Menu } from 'semantic-ui-react'
import SignedIn from './SignedIn'

export default function SignedOut() {
    return (
        <div>
            <Menu.Item>
               <Button  onClick={SignedIn} primary>Giriş yap</Button>
               <Button primary style={{marginLeft:'0.4em'}}>Kayıt Ol</Button> 
            </Menu.Item>
        </div>
    )
}
