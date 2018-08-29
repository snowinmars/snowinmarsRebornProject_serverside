import React, { Component } from 'react';
var Config = require('Config');

class BookExpand extends Component {
    render() {
        return (
            <div className="simr-flex simr-flex-wrap simr-expanded-book">
                <div className="simr-flex simr-flex-align-start simr-book-description">
                    <span className="simr-image">
                        <img alt="simr-book" src={this.props.row.imageUrl} />
                    </span>

                    <span className="simr-additional-info">
                        {this.props.row.additionalInfo}
                    </span>
                </div>

                <div className="simr-main-book-info">
                    <span className="title">{this.props.row.title}</span>

                    <span className="simr-authors">
                        {this.props.row.authors.map(author => {
                            return (
                                <a
                                    href={
                                        Config.url.author + '?id=' + author.id
                                    }
                                    key={author.key}
                                >
                                    <span className="simr-author">
                                        {author.name.givenName +
                                            ' ' +
                                            author.name.fullMiddleName +
                                            ' ' +
                                            author.name.familyName}
                                    </span>
                                </a>
                            );
                        })}
                    </span>
                </div>

                <div className="simr-secondary-book-info simr-flex simr-flex-direction-column simr-flex-wrap">
                    <span className="simr-bookshelf">
                        Bookshelf: {this.props.row.bookshelf}
                    </span>
                    <span className="simr-links">
                        <a href={this.props.row.flibustaUrl}>Flibusta</a>
                        <a href={this.props.row.libRusEcUrl}>LibRusEc</a>
                        <a href={this.props.row.liveLibUrl}>LiveLib</a>
                    </span>
                    <span className="simr-owner">
                        Owner: {this.props.row.owner}
                    </span>
                    <span className="simr-page-count">
                        Page count: {this.props.row.pageCount}
                    </span>
                    <span className="simr-year">
                        Year: {this.props.row.year}
                    </span>
                </div>
            </div>
        );
    }
}

export default BookExpand;
