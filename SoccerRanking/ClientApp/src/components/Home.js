import * as React from 'react';
import styled from 'styled-components';
import { Layout } from './Layout';
import { NavBar } from './NavBar';
import { Players } from './Players';
import { Tournament } from './Tournament';
import { Teams } from './Teams';
import { Rankings } from './Rankings';

export class Home extends React.Component {

    constructor(props) {
        super(props);

        this.updatePage = this.updatePage.bind(this);
        this.renderPage = this.renderPage.bind(this);

        this.state = {
            currentPage: ''
        };
    }

    render() {
        return (
            <Layout updatePage={this.updatePage} >
                {this.renderPage()}
            </Layout>
        );
    }

    renderPage() {
        switch (this.state.currentPage) {
            case 'players': return <Players />;
            case 'teams': return <Teams />;
            case 'rankings': return <Rankings />;
            case 'tournament': return <Tournament />;
            default: return false;
        }
    }

    updatePage(page) {
        this.setState({ currentPage: page });
    }
}
