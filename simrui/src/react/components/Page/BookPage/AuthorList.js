import React, { PureComponent } from 'react';
import List from '../../App/List/List';
import { Link } from 'react-router-dom';

var Config = require('Config');

class AuthorList extends PureComponent {
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
            return <Link to={Config.url.author + '?id=' + author.id} className="simr-author-item">
                        {author.name.givenName[0] +
                            '. ' +
                            author.name.fullMiddleName[0] +
                            '. ' +
                            author.name.familyName}
                </Link>;
        };
    }
}

export default AuthorList;
