import styled, { css } from 'styled-components';
import { Avatar, Button, Layout, Menu } from 'antd';
import mainBackground from '../../assets/main-background.jpg';

const { Header } = Layout;

export const MainHeader = styled.header`
  background-color: #000;
`;

export const HeaderMenu = styled(Menu)`
  &.ant-menu.ant-menu-dark .ant-menu-item-selected,
  &.ant-menu-submenu-popup.ant-menu-dark .ant-menu-item-selected,
  &.ant-menu-dark.ant-menu-horizontal > .ant-menu-item {
    background-color: #000;
  }
  &.ant-menu-dark.ant-menu-horizontal > .ant-menu-item:hover {
    background-color: #000;
  }
`;

export const MenuItem = styled(Menu.Item)`
  &.ant-menu-item {
    color: #fff;
    font-weight: bold;
    font-size: 16px;
    &:hover{
        color: red;
    }
  }
`;

export const Container = styled.div`
  max-width: 1180px;
  display: flex;
  justify-content: space-between;
  margin: auto;
  align-items: center;
`;

export const AntdAvatar = styled(Avatar)`
  background-color: ${(props) => props.backgroundColor};
  vertical-align: middle;
`;

export const AvatarContainer = styled.div`
  position: relative;
`;

export const Login = styled(Button)`
  size: small;
  &.ant-btn:hover {
    background-color: #06c;
    color: #fff;
  }
`;

export const Main = styled.main`
  background-image: url(${mainBackground});
  background-size: cover;
  background-attachment: fixed;
`;
