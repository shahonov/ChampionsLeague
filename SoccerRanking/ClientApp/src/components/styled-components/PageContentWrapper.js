import styled from 'styled-components';

export const PageContentWrapper = styled.div`
    margin: 0 100px 100px 100px;
    border: 1px solid #CCC;
    border-radius: 5px;
    padding: 20px;
    transition: .3s;
    &:hover {
        background-image: linear-gradient(#e9d6ff, white);
        border: 1px solid #777;
        border-radius: 10px;
        box-shadow: 1px 1px 10px #AAA;
        transition: .3s;
    }
`;