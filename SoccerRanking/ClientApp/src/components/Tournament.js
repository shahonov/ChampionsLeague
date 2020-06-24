import * as React from 'react';
import styled from 'styled-components';
import { PageContentWrapper } from './styled-components/PageContentWrapper';

const Heading = styled.h3`
    font-family: monospace;
    text-decoration: underline;
`;

const Text = styled.p`
    font-family: monospace;
    font-size: 14px;
`;

export class Tournament extends React.Component {
    render() {
        return (
            <PageContentWrapper>
                <Heading>Champions League</Heading>
                <Text>
                    {/* generated from markdown */}
                    <p>
                        <strong>The UEFA Champions League</strong>
                        (also known as the <em>European Cup</em>)
                        is an annual club football competition organised by the
                        <strong>Union of European Football Associations</strong>
                        <strong>
                            <em>(UEFA)</em>
                        </strong>
                        and contested by <em>top-division</em>
                        European clubs, deciding the competition winners.
                        It is <em>one of the most prestigious</em>
                        football tournaments in the world and
                        <em>the most prestigious</em>
                        club competition in European football,
                        played by the national league champions (and, for some nations, one or more runners-up)
                        of their national associations.
                        <strong>Introduced in 1955</strong>
                        as the
                        <strong>
                            <em>European Champion Clubs&#39; Cup</em>
                        </strong>
                        , it was initially a straight knockout tournament open only
                        to the champion club of each national championship.
                        The competition took on its current name in 1992,
                        adding a round-robin group stage and allowing multiple entrants from certain countries.
                        <em>It has since been expanded</em>
                        , and while most of Europe&#39;s national leagues can still only enter their champion,
                        the strongest leagues now provide
                        <strong>up to four teams.</strong>
                        Clubs that finish next-in-line in their national league,
                        having not qualified for the Champions League,
                        are eligible for
                        <strong>the second-tier UEFA Europa League competition</strong>
                        , and from 2021, teams not eligible for the UEFA Europa League will qualify for
                        <em>a new</em>
                        <strong>third-tier competition</strong>
                        called the
                        <strong>
                            <em>UEFA Europa Conference League.</em>
                        </strong>
                        In its present format, the
                        <strong>Champions League</strong>
                        <em>begins in late June</em>
                        with a preliminary round,
                        <em>three qualifying rounds</em>
                        and a
                        <em>play-off round</em>
                        , all played over two legs.
                        <strong>The six surviving teams enter the group stage</strong>
                        ,
                        <em>joining 26 teams qualified in advance.</em>
                        <strong>
                            The 32 teams are drawn into eight groups of four teams
                            and play each other in a double round-robin system.
                        </strong>
                        <em>
                            The eight group winners and eight runners-up proceed to the knockout
                            phase that culminates with the final match in late May or early June.
                        </em>
                        <strong>
                            The winner of the Champions League qualifies for the following year&#39;s
                            Champions League, the UEFA Super Cup and the FIFA Club World Cup.
                        </strong>
                    </p>
                </Text>
            </PageContentWrapper>
        );
    }
}