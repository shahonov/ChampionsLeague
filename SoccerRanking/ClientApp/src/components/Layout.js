import * as React from 'react';
import styled from 'styled-components';
import { NavBar } from './NavBar';
import soccerBall from '../assets/soccer-ball.svg';

const Header = styled.div`
    height: 100px;
    display: flex;
    flex-wrap: wrap;
    justify-content: flex-start;
    align-items: center;
`;

const IconBall = styled.img`
    width: 10%;
    padding: 10px;
    height: 100%;
`;

const Heading = styled.h1`
    font-family: monospace;
`;

const LayoutWrapper = styled.div`
    background-image: linear-gradient(#e9d6ff, white);
    min-height: 500px;
`;

const Footer = styled.div`
    
`;

export class Layout extends React.Component {
    render() {
        return (
            <LayoutWrapper>
                <Header>
                    <IconBall src={soccerBall} alt='soccer-ball-icon' />
                    <Heading>Soccer Mania - Champions League</Heading>
                </Header>
                <NavBar updatePage={this.props.updatePage} />
                {this.props.children}
            </LayoutWrapper>
        );
    }
}