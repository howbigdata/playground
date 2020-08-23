import React from 'react';
import BarChart from './components/BarChart'
import { useFetch } from "./hook"

function Foo(props) {

	const [impact, impact_loaded] = useFetch(
    '/api/process/'+props.process.id+'/solve'
  );
  const [detail, detail_loaded] = useFetch(
    '/api/process/'+props.process.id
  );
  var results = props.methods.reduce(function(results, m) {
    (results[m.id] = results[m.id] || []).push(m);
    return results;
}, {})
	return (<><hr/> 
		<h3>LCI</h3>
         <BarChart title={props.process.name} data={detail.elementaryExchanges} />
 		 <h3>LCIA</h3>
         <p>{JSON.stringify(impact)}</p>
		</>)
}

function App(props) {
 
   const [methods, methods_loaded] = useFetch(
    '/api/method'
  );
   const [processes, process_loaded] = useFetch(
    '/api/process'
  );
    return (
    <>
      {process_loaded ? (
        "Loading..."
      ) : (
         <div>
 		 <h3>processes</h3>
        {processes.map(function(d, idx){
        	 	return (<Foo methods={methods} process={d} />)
        	 })}

       
        
        	 
        	</div>
      )}
    </>
  );
}

export default App;
