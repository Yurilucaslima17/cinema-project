import Login from './login';
import Avatar from './avatar';
import Logo from '../../assets/logo-cinema.png';
import {MainHeader, Container, HeaderMenu, MenuItem} from '../../styles/home';
import { useState } from 'react';
import { useRouter } from 'next/router';

export default function Header(){
    const [isLogedIn, setIsLogged] = useState(false);

    const router = useRouter();

    return(
        <MainHeader>
            <Container>
            <img src={Logo} alt="Created by Susana Bispo" />
            <HeaderMenu
                theme="dark"
                mode="horizontal"
                defaultSelectedKeys={['1']}
            >
                <MenuItem key="1" onClick={() => router.push('/')}>
                Filmes
                </MenuItem>
                <MenuItem key="2" onClick={() => router.push('/salas')}>
                Salas
                </MenuItem>
                <MenuItem key="3" onClick={() => router.push('/sessoes')}>
                Sessões
                </MenuItem>
            </HeaderMenu>
            {isLogedIn ? <Avatar>T</Avatar> : <Login>Login</Login>}
            </Container>
        </MainHeader>
    )
}