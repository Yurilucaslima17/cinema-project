import styled, { css } from 'styled-components';

export const CrudLine = styled.div`
    display: flex;
    justify-content: space-between;
    max-width: 800px;
    margin: 0.2rem auto;
    align-items: center;
    border-top: 1px solid;
    &:last-child{
        border-bottom: 1px solid;
    }
    div{
        display: flex;
    }
`;

export const Main = styled.main`
    background-color: #add8e6;
    padding: 1rem 0;
`;

export const AddContainer = styled.div`
    span{
        margin: 1rem auto;
        display: block;
    }
`;

export const Operations = styled.div`
    align-items: center;
    span{
        margin: 0 1rem;
        font-size: 1.2rem;
        cursor: pointer;
        svg{
            vertical-align: inherit;
        }
    }
`;

export const Formulario = styled.form`
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    margin: 0.5rem 1rem;

    &>input, &> label{
        /* flex: 0 48%; */
    }

    label{
        display: flex;
        max-width:250px;
        input{
            margin-left: 1rem;
        }
    }

    input{
        max-width:200px;
    }
`;