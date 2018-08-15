import React, { Component } from 'react';
import List from './../../App/List/List'

class AuthorList extends Component {
    render() {
        if (this.props.authors) {
            return <List
                className="simr-author-list"
                items={this.props.authors}
                itemRender={this.renderAuthor()} />;
        }
    }

    renderAuthor() {
        return function (author) {
            return <span className="simr-author-item">
                {author.givenName +
                    ' ' +
                    author.fullMiddleName +
                    ' ' +
                    author.familyName}
            </span>;
        };
    }
}

export default AuthorList;