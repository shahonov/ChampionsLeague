import * as React from 'react';
import styled from 'styled-components';
import { PageContentWrapper } from './styled-components/PageContentWrapper';
import goalsIcon from '../assets/goal.svg';
import yellowCard from '../assets/yellow-card.svg';
import redCard from '../assets/red-card.svg';

const TableRow = styled.tr`
    cursor: pointer;
    transition: .3s;
    &.selected {
        border: 1px solid #CCC;
        border-radius: 10px;
        color: white;
        background-color: #777;
        transition: .3s;
    }
`;

const TableHeadIcon = styled.img`
    width: 20px;
`;

export class Players extends React.Component {

    playerRoles = ['Goalkeeper', 'Defender', 'Midfielder', 'Attacker'];

    constructor(props) {
        super(props);

        this.handleTeamSelect = this.handleTeamSelect.bind(this);
        this.handlePlayerChange = this.handlePlayerChange.bind(this);

        this.state = {
            teams: [],
            selectedTeam: {},
            players: []
        };

        fetch('/api/teams/all')
            .then(x => x.json())
            .then(x => this.setState({ teams: x }))
            .catch(x => console.error(x));
    }

    render() {
        let selectedTeamName = '';
        if (typeof this.state.selectedTeam === "number") {
            selectedTeamName = this.state.teams.find(x => x.id === this.state.selectedTeam).name;
        }

        return (
            <PageContentWrapper>
                <h4>{selectedTeamName === '' ? 'Select a team...' : selectedTeamName}</h4>
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
                                const teamID = this.state.selectedTeam;
                                const isSelected = typeof teamID === "number" && x.id === teamID;
                                return (
                                    <TableRow
                                        id={x.id}
                                        key={x.id}
                                        onClick={this.handleTeamSelect}
                                        className={isSelected ? 'selected' : ''}>
                                        <td>{x.id}</td>
                                        <td>{x.name}</td>
                                    </TableRow>
                                );
                            })
                        }
                    </tbody>
                </table>
                <hr />
                {
                    this.state.players.length > 0 &&
                    <div>
                        <h4>{`${selectedTeamName}'s Players`}</h4>
                        <table className='table table-hover'>
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Role</th>
                                    <th>
                                        <TableHeadIcon src={goalsIcon} alt='goals-icon' />
                                        <span>Goals</span>
                                    </th>
                                    <th>
                                        <TableHeadIcon src={yellowCard} alt='yellow-cards-icon' />
                                        <span>Cards</span>
                                    </th>
                                    <th>
                                        <TableHeadIcon src={redCard} alt='red-cards-icon' />
                                        <span>Cards</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.players.map(x => {
                                        return (
                                            <TableRow key={x.id}>
                                                <td>{x.id}</td>
                                                <td>{x.name}</td>
                                                <td>{this.playerRoles[x.role]}</td>
                                                <td>{x.scoredGoals}</td>
                                                <td>{x.yellowCards}</td>
                                                <td>{x.redCards}</td>
                                            </TableRow>
                                        );
                                    })
                                }
                            </tbody>
                        </table>
                    </div>
                }
            </PageContentWrapper>
        );
    }

    handleTeamSelect(ev) {
        const teamID = ev.currentTarget.id;
        fetch(`api/players/${teamID}`)
            .then(x => x.json())
            .then(x => {
                this.setState({
                    selectedTeam: +teamID,
                    players: x
                });
            })
            .catch(x => console.error(x));
    }

    handlePlayerChange(ev) {
        const playerID = ev.currentTarget.value;
        this.setState({
            selectedPlayer: +playerID
        });
    }
}