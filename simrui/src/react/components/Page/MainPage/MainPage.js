import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Head from './../../App/Head/Head';
import Bot from './../../App/Bot/Bot';
import WelcomePage from './../WelcomePage/WelcomePage';
import BookPage from './../BookPage/BookPage';
import PhotoPage from './../PhotoPage/PhotoPage';
import VideoPage from './../VideoPage/VideoPage';
import PathOfExilePage from './../PathOfExilePage/PathOfExilePage';
import ChatPage from './../ChatPage/ChatPage';
import AuthorPage from './../AuthorPage/AuthorPage';
import SiberiaPage from './../SiberiaPage/SiberiaPage';
import './MainPage.scss';

const Config = require('Config');

class MainPage extends Component {
    render() {
        return <BrowserRouter>
                <div className="simr-r-MainPage simr-grid-container">
                    <Head />

                    <section className="simr-container">
                        <Switch>
                            <Route
                                exact
                                path={Config.url.root}
                                component={WelcomePage}
                            />
                            <Route
                                path={Config.url.book}
                                component={BookPage}
                            />
                            <Route
                                path={Config.url.photo}
                                component={PhotoPage}
                            />
                            <Route
                                path={Config.url.video}
                                component={VideoPage}
                            />
                            <Route
                                path={Config.url.pathofexile}
                                component={PathOfExilePage}
                            />
                            <Route
                                path={Config.url.chat}
                                component={ChatPage}
                            />
							<Route 
								path={Config.url.author}
								component={AuthorPage} />
                            <Route
                                path={Config.url.siberia}
                                component={SiberiaPage}
                            />
                        </Switch>
                    </section>

                    <Bot />
                </div>
            </BrowserRouter>;
    }
}

export default MainPage;
