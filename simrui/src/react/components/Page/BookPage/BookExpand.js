import React, { Component } from 'react';

class BookExpand extends Component {
    render() {
        console.log(this.props.row);

        return <div className="simr-flex simr-flex-wrap simr-expanded-book">
                <div className="simr-flex simr-flex-align-start book-description">
                    <span className="image">
                        <img alt="book" src={this.props.row.imageUrl} />
                    </span>

                    <span className="additional-info">
                        {this.props.row.additionalInfo}
                    </span>
                </div>

                <div className="main-book-info">
                    <span className="title">
                        {this.props.row.title}
                    </span>

                    <span className="authors">
                        {this.props.row.authors.map(author => {
                            return <span className="author">
                                    {author.givenName +
                                        ' ' +
                                        author.fullMiddleName +
                                        ' ' +
                                        author.familyName}
                                </span>;
                        })}
                    </span>
                </div>

                <div className="secondary-book-info simr-flex simr-flex-direction-column simr-flex-wrap">
                    <span className="bookshelf">
                        Bookshelf: {this.props.row.bookshelf}
                    </span>
                    <span className="links">
                        <a href={this.props.row.flibustaUrl}>
                            Flibusta
                        </a>
                        <a href={this.props.row.libRusEcUrl}>
                            LibRusEc
                        </a>
                        <a href={this.props.row.liveLibUrl}>LiveLib</a>
                    </span>
                    <span className="owner">
                        Owner: {this.props.row.owner}
                    </span>
                    <span className="page-count">
                        Page count: {this.props.row.pageCount}
                    </span>
                    <span className="year">
                        Year: {this.props.row.year}
                    </span>
                </div>
            </div>;
    }
}

export default BookExpand;
