import * as React from 'react';
import { PageContentWrapper } from './styled-components/PageContentWrapper';

export class Rankings extends React.Component {

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
        let ordered = [];
        if (this.state.teams.length > 0) {
            ordered = this.state.teams.sort((x, y) => +x.points - +y.points);
            ordered.reverse();
        }

        return (
            <PageContentWrapper>
                <h4>Ranking</h4>
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">TeamID</th>
                            <th scope="col">Name</th>
                            <th scope="col">Points</th>
                            <th scope="col">Wins</th>
                            <th scope="col">Draws</th>
                            <th scope="col">Losses</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            ordered.map(x => {
                                return (
                                    <tr key={x.id}>
                                        <td>{x.id}</td>
                                        <td>{x.name}</td>
                                        <th scope='row'>{x.points}</th>
                                        <td>{x.wins}</td>
                                        <td>{x.draws}</td>
                                        <td>{x.losses}</td>
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