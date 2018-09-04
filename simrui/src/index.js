import React from 'react';
import ReactDOM from 'react-dom';
import './index.scss';
import './../src/css/flex.scss';
import './../src/css/grid.scss';
import MainPage from './react/components/Page/MainPage/MainPage';
import registerServiceWorker from './registerServiceWorker';

if (process.env.NODE_ENV !== 'production') {
    const { whyDidYouUpdate } = require('why-did-you-update');
    whyDidYouUpdate(React);
}

// TODO C:\prg_my\snowinmarsRebornProject\simrui\node_modules\react-bootstrap-table2-paginator\lib\src\pagination.js
// TODO find 'var pageListClass' > change 'col-*-6' to 'col-*-4'
// TODO find 'className' > change 'col-*-6' to 'col-*-8'

ReactDOM.render(<MainPage />, document.getElementById('root'));
registerServiceWorker();
