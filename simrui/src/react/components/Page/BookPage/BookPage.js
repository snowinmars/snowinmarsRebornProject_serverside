import 'react-bootstrap-table-next/dist/react-bootstrap-table2.min.css';
import './BookPage.scss';

import React, { PureComponent } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import ToolkitProvider from 'react-bootstrap-table2-toolkit';
import { Link } from 'react-router-dom';

import AuthorList from './AuthorList';
import BookExpand from './BookExpand';
import Filter from './../../App/Filter/Filter';
import Loader from '../../App/Loader/Loader';

const Config = require('Config');
const Lib = require('./../../../Lib/componentUtils');

class BookPage extends PureComponent {
    constructor(props) {
        super(props);

        const data = this.getDefaultData();

        this.state = {
            isInitByFirstPage: false,
            isInitByAllData: false,
            gotApiError: false,
            hasErrors: false,
            response: {
                code: -1,
                data: data
            }
        };

        this.options = Config.bootstrapTableOptions;
        this.table = React.createRef();
    }

    componentDidMount() {
        Lib.fetchAndHandle({
            uri: Config.apiurl.book.filter,
            data: {
                page: {
                    number: 0,
                    size: 25
                }
            },
            onSuccess: json => {
                this.setState({
                    response: JSON.parse(json),
                    isInitByFirstPage: true
                });

                Lib.fetchAndHandle({
                    uri: Config.apiurl.book.filter,
                    data: {
                        page: {
                            number: 0,
                            size: 1000
                        }
                    },
                    onSuccess: json => {
                        this.setState({
                            response: JSON.parse(json),
                            isInitByAllData: true
                        });
                    },
                    onError: this.onError
                });
            },
            onError: this.onError
        });
    }

    onError = err =>
        this.setState({
            gotApiError: true,
            hasErrors: true,
            isInitByFirstPage: false,
            isInitByAllData: false
        });

    getActions() {
        return (
            <div className="simr-page-actions simr-flex simr-flex-justify-space-between">
                <span className="simr-btn">Add new book</span>

                <Link to={Config.url.author}>
                    <span className="simr-btn">All authors</span>
                </Link>
            </div>
        );
    }

    getDefaultData() {
        const defaultUser = {
            title: 'Loading...',
            authors: [
                {
                    name: {
                        givenName: 'Loading...',
                        fullMiddleName: 'Loading...',
                        familyName: 'Loading...',
                        key: 0
                    }
                }
            ],
            year: 'Loading...',
            imageUrl: 'Loading...',
            additionalInfo: 'Loading...',
            bookshelf: 'Loading...',
            flibustaUrl: 'Loading...',
            libRusEcUrl: 'Loading...',
            liveLibUrl: 'Loading...',
            owner: 'Loading...',
            pageCount: 'Loading...',
            key: 0
        };

        const data = [];

        for (let i = 0; i < 10; i++) {
            defaultUser.key = Math.random();
            defaultUser.authors[0].key = Math.random();
            data.push(defaultUser);
        }

        return data;
    }

    getRow = i => {
        return this.state.response.data[i.index];
    };

    isExpandableRow = row => {
        return true;
    };

    expandComponent = row => {
        return <BookExpand row={row} />;
    };

    authorsFormatter = cell => {
        return <AuthorList authors={cell} />;
    };

    expandColumnComponent = ({ expanded }) => {
        let content = expanded ? 'expand_more' : 'expand_less';

        return <i className="material-icons">{content}</i>;
    };

    getTable(options) {
        const columns = [
            {
                dataField: 'title',
                text: 'Title',
                sort: true
            },
            {
                dataField: 'authors',
                text: 'Authors',
                formatter: this.authorsFormatter,
                filterValue: authors => {
                    return authors.map(author => author.fullname);
                },
                sort: true
            },
            {
                dataField: 'year',
                text: 'Year',
                sort: true
            },
            {
                dataField: 'bookshelf',
                text: 'Bookshelf',
                sort: true
            },
            {
                dataField: 'additionalInfo',
                text: 'Hidden_additionalInfo',
                sort: true,
                hidden: true
            }
        ];

        return (
            <ToolkitProvider
                keyField="key"
                data={this.state.response.data}
                columns={columns}
                search
            >
                {props => (
                    <div>
                        <Filter />
                        <BootstrapTable
                            ref={this.table}
                            hover
                            pagination={paginationFactory(options)}
                            expandRow={{
                                renderer: this.expandComponent,
                                showExpandColumn: true,
                                expandColumnRenderer: this
                                    .expandColumnComponent,
                                expandHeaderColumnRenderer: () => null
                            }}
                            {...props.baseProps}
                        />
                    </div>
                )}
            </ToolkitProvider>
        );
    }

    render() {
        const loader = (
            <Loader
                hasErrors={this.state.gotApiError}
                isHidden={this.state.isInitByFirstPage}
            />
        );

        const actions = this.getActions();

        const table = this.getTable(this.options);

        return (
            <div>
                {loader}
                {actions}
                {table}
            </div>
        );
    }
}

export default BookPage;
