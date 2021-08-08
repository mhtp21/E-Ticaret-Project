import React from 'react'
import { Dropdown, Menu } from 'semantic-ui-react'
import SignedOut from './SignedOut'


export default function SignedIn() {
    return (
        <div>
            <Menu.Item>
                <Dropdown pointing="top left" text="Muhammed Hatipoğlu">
                    <Dropdown.Menu>
                        <Dropdown.Item text="Bilgilerim" icon="info" />
                        <Dropdown.Item onClick={SignedOut} text="Çıkış Yap" icon="sign-out"/>
                    </Dropdown.Menu>
                </Dropdown>
            </Menu.Item>            
        </div>
    )
}
