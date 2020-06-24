import * as React from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';

export default class App extends React.Component {
    render() {
        return (
            <div>
                <Route exact path='/' component={Home} />
            </div>
        );
    }
}
