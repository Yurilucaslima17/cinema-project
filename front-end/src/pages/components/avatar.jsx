import {AntdAvatar, AvatarContainer} from '../../styles/home';
import {useState} from 'react';
import Logout from './logout'

export default function Avatar() {

    const [isActive, setIsActive] = useState(false)

    function changeState() {
        setIsActive(!isActive)
    }

    return(
        <>
        <AntdAvatar>T</AntdAvatar>
        {isActive && <AvatarContainer>
                <a href="/profile"></a>
                <Logout>Logout</Logout>
            </AvatarContainer>}
        </>
    )
}