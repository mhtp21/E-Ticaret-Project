import React from 'react'
import { Menu } from 'semantic-ui-react'


export default function Categories() {
    return (
        <div>
            <Menu pointing vertical>
                <Menu.Item name="Elektronik"/>
                <Menu.Item name="Ev&Yaşam"/>
                <Menu.Item name="Spor"/>
                <Menu.Item name="Kozmetik"/>
                <Menu.Item name="Moda"/>
            </Menu>
        </div>
    )
}
