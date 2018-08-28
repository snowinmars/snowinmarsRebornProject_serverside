import React, { Component } from 'react';
import './AuthorPage.scss';
import AuthorsBooksTable from './AuthorsBooksTable';

var Lib = require('./../../../Lib/componentUtils');
var Config = require('Config');

class AuthorPage extends Component {
    constructor(props) {
        super(props);

        var data = this.getDefaultData();

        this.state = {
            isInitByAuthorData: false,
            gotApiError: false,
            hasErrors: false,
            response: {
                code: -1,
                data: data
            }
        };
    }

    componentDidMount() {
        Lib.fetchAndHandle({
            uri: Config.apiurl.author.get,
            data: {
                id: 'c5fbd054-c087-45c5-b1d2-f27da0f75353'
            },
            method: 'GET',
            onSuccess: json => {
                this.setState({
                    response: JSON.parse(json),
                    isInitByAuthorData: true
                });
            },
            onError: this.onError
        });
    }

    onError = err =>
        this.setState({
            gotApiError: true,
            hasErrors: true,
            isInitByAuthorData: false
        });

    getDefaultData() {
        return {
            name: {
                givenName: 'Loading...',
                fullMiddleName: 'Loading...',
                familyName: 'Loading...',
                key: 0
            },
            pseudonym: {
                givenName: 'Loading...',
                fullMiddleName: 'Loading...',
                familyName: 'Loading...',
                key: 0
            },
            aka: 'Loading...'
        };
    }

    render() {
        var loader = this.getLoader();

        var author = this.getAuthor();

        return (
            <div>
                {loader}
                {author}
                <div className="simr-author-books">
                    <AuthorsBooksTable />
                </div>
            </div>
        );
    }

    getAuthor() {
        var pseudonym;
        if (this.state.response.data.pseudonym) {
            pseudonym = (
                    <div className="simr-author-pseudonym">
                        <span>Pseudonym:</span>
                        <span>
                            {this.state.response.data.pseudonym.familyName}
                        </span>
                        <span>
                            {this.state.response.data.pseudonym.fullMiddleName}
                        </span>
                        <span>
                            {this.state.response.data.pseudonym.givenName}
                        </span>
                    </div>
            );
        }

        var name;
        if (this.state.response.data.pseudonym) {
            name = (
                <span className="simr-author-name">
                    <span>{this.state.response.data.name.familyName}</span>
                    <span>{this.state.response.data.name.fullMiddleName}</span>
                    <span>{this.state.response.data.name.givenName}</span>
                </span>
            );
        }

        return <span className="simr-author simr-grid-container">
                {name}
                {pseudonym}
                <span className="simr-author-aka">
                    As known as: {this.state.response.data.aka}
                </span>

                <img className="simr-author-photo" src={this.state.response.data.photoUrl} alt="author" />
                <span className="simr-author-info">{this.state.response.data.info}</span>
            </span>;
    }

    getLoader() {
        var loaderClass =
            'simr-flex simr-flex-align-center simr-flex-justify-center';

        if (this.state.gotApiError) {
            loaderClass += ' simr-loader-api-error ';
        }

        if (this.state.isInitByAuthorData) {
            loaderClass += ' simr-loader hidden ';
        } else {
            loaderClass += ' simr-loader ';
        }

        const loader = (
            <div className={loaderClass}>
                <div className="sk-folding-cube">
                    <div className="sk-cube1 sk-cube" />
                    <div className="sk-cube2 sk-cube" />
                    <div className="sk-cube4 sk-cube" />
                    <div className="sk-cube3 sk-cube" />
                </div>
            </div>
        );
        return loader;
    }
}

export default AuthorPage;
