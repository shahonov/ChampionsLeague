import * as React from 'react';
import { PageContentWrapper } from './styled-components/PageContentWrapper';

export class Teams extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            teams: []
        }

        fetch('/api/teams/all')
            .then(x => x.json())
            .then(x => this.setState({ teams: x }))
            .catch(x => console.error(x));
    }

    render() {
        return (
            <PageContentWrapper>
                <h4>Teams</h4>
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">TeamID</th>
                            <th scope="col">Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.teams.map(x => {
                                return (
                                    <tr key={x.id}>
                                        <td>{x.id}</td>
                                        <td>{x.name}</td>
                                    </tr>
                                );
                            })
                        }
                    </tbody>
                </table>
            </PageContentWrapper>
        );
    }
}