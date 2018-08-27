import React, { Component } from 'react';
import List from '../../App/List/List';

var Config = require('Config');

class AuthorList extends Component {
    render() {
        if (this.props.authors) {
            return (
                <List
                    className="simr-author-list"
                    items={this.props.authors}
                    itemRender={this.renderAuthor()}
                />
            );
        }
    }

    renderAuthor() {
        return function(author) {
            return (
                <a href={Config.url.author + '?id=' + author.id}>
                    <span className="simr-author-item">
                        {author.name.givenName[0] +
                            '. ' +
                            author.name.fullMiddleName[0] +
                            '. ' +
                            author.name.familyName}
                    </span>
                </a>
            );
        };
    }
}

export default AuthorList;
