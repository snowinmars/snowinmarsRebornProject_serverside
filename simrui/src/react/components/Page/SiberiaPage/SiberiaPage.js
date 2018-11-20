import React, { Component } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import ToolkitProvider from 'react-bootstrap-table2-toolkit';
import 'react-bootstrap-table-next/dist/react-bootstrap-table2.min.css';
import './SiberiaPage.scss';
import Filter from './../../App/Filter/Filter';
import { Link } from 'react-router-dom';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class SiberiaPage extends Component {
    constructor(props) {
        super(props);

        var data = this.getDefaultData();

        this.state = {
            isInit: false,
            gotApiError: false,
            hasErrors: false,
            response: {
                code: -1,
                data: data
            }
        };

        this.options = Config.bootstrapTableOptions;

        this.getRow = this.getRow.bind(this);
    }

    componentDidMount() {
        Lib.fetchAndHandle({
            uri: Config.apiurl.siberia.filter,
            onSuccess: json =>
                this.setState({
                    response: JSON.parse(json),
                    isInit: true
                }),
            onError: err =>
                this.setState({
                    gotApiError: true,
                    hasErrors: true,
                    isInit: false
                })
        });
    }

    getActions() {
        return (
            <div className="simr-page-actions simr-flex simr-flex-justify-space-between">
                <Link to={Config.url.siberia_createEnvironment}>
                    <span className="material-icons simr-btn">add</span>
                </Link>
            </div>
        );
    }

    getDefaultData() {
        var defaultUser = {
            name: 'Loading...',
            enviroment: 'Loading...',
            actions: 'Loading...',
            key: 0
        };

        var data = [];

        for (var i = 0; i < 10; i++) {
            data.push(defaultUser);
        }

        return data;
    }

    getRow(i) {
        return this.state.response.data[i.index];
    }

    deleteEnvironment = (e) => {
        const id = e.target.dataset.environment;

        Lib.fetchAndHandle({
            uri: Config.apiurl.siberia.delete,
            data: id,
            onSuccess: json =>
                console.log(json, id),
            onError: err =>
                this.setState({
                    gotApiError: true,
                    hasErrors: true,
                    isInit: false
                })
        });
    }

    actionsFormatter = (cell, row) => {
        return (
            <span>
                <Link to={Config.url.siberia_editEnvironment}>
                    <span className='simr-btn material-icons material-icons-font-18'>create</span>
                </Link>

                <span className='simr-btn material-icons material-icons-font-18' data-environment={row.id} onClick={this.deleteEnvironment}>delete</span>
            </span>
        );
    }

    getTable(options) {
        const columns = [
            {
                dataField: 'environment',
                text: 'Environment',
                sort: true,
            },
            {
                dataField: 'name',
                text: 'Branch',
                sort: true
            },
            {
                dataField: '_actions',
                text: '',
                sort: false,
                editable: false,
                align: 'right',
                headerAttrs: { 'width': '10%' },
                formatter: this.actionsFormatter
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
                        <Filter isBlock={true} />
                        <BootstrapTable
                            ref={this.table}
                            hover
                            classes='simr-table'
                            pagination={paginationFactory(options)}
                            {...props.baseProps}
                        />
                    </div>
                )}
            </ToolkitProvider>
        );
    }

    getLoader() {
        var loaderClass = '';

        if (this.state.gotApiError) {
            loaderClass += ' simr-loader-api-error ';
        }

        if (this.state.isInit) {
            loaderClass += ' simr-loader hidden ';
        } else {
            loaderClass += ' simr-loader ';
        }

        const loader = (
            <div
                className={
                    loaderClass +
                    'simr-flex simr-flex-align-center simr-flex-justify-center'
                }
            >
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

    render() {
        const loader = this.getLoader();

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

export default SiberiaPage;
