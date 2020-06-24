import * as React from 'react';
import styled from 'styled-components';
import rankingIcon from '../assets/ranking.svg';
import playerIcon from '../assets/soccer-player.svg';
import teamIcon from '../assets/soccer-team.svg';
import tournamentIcon from '../assets/tournament.svg';

const CenterFlex = styled.div`
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
`;

const RankingWrapper = styled(CenterFlex)`
    height: 100px;
`;

const IconLabelWrapper = styled(CenterFlex)`
    width: 6%;
    height: 70%;
    transition: .3s;
    &:hover {
        width: 7%;
        height: 90%;
        cursor: pointer;
        border: 1px solid #CCC;
        border-radius: 5px;
        transition: .3s;
    }
`;

const Icon = styled.img`
    height: 70%;   
`;

const Label = styled.label`
    height: 30%;
    width: 100%;
    text-align: center;
    font-family: monospace;
`;

export class NavBar extends React.Component {

    constructor(props) {
        super(props);

        this.handleRankingsClick = this.handleRankingsClick.bind(this);
        this.handlePlayersClick = this.handlePlayersClick.bind(this);
        this.handleTeamsClick = this.handleTeamsClick.bind(this);
        this.handleTournamentClick = this.handleTournamentClick.bind(this);
    }

    render() {
        return (
            <RankingWrapper>
                <IconLabelWrapper onClick={this.handleTeamsClick}>
                    <Icon src={teamIcon} alt='team-icon' />
                    <Label>Teams</Label>
                </IconLabelWrapper>
                <IconLabelWrapper onClick={this.handlePlayersClick}>
                    <Icon src={playerIcon} alt='player-icon' />
                    <Label>Players</Label>
                </IconLabelWrapper>
                <IconLabelWrapper onClick={this.handleRankingsClick}>
                    <Icon src={rankingIcon} alt='ranking-icon' />
                    <Label>Rankings</Label>
                </IconLabelWrapper>
                <IconLabelWrapper onClick={this.handleTournamentClick}>
                    <Icon src={tournamentIcon} alt='tournament-icon' />
                    <Label>Tournament</Label>
                </IconLabelWrapper>
            </RankingWrapper>
        );
    }

    handleRankingsClick() {
        this.props.updatePage('rankings');
    }

    handlePlayersClick() {
        this.props.updatePage('players');
    }

    handleTeamsClick() {
        this.props.updatePage('teams');
    }

    handleTournamentClick() {
        this.props.updatePage('tournament');
    }
}