import React, { useRef, useState } from "react";
import { stringify } from 'query-string';
function App() {
    const [loading, setLoading] = useState(true)
    const [getResult, setGetResult] = useState([]);
    const [value, setValue] = useState("");
    async function getAllData() {
        setLoading(true)
        try {
            const res = await fetch(`https://localhost:7106/api/Product/getAllData`);
            const data = await res.json();
            console.log(data)
            setGetResult(data);
            setLoading(false)
        } catch (err) {
            setGetResult(err.message);
        }
    }
    async function deleteRecord() {
        console.log(value);
       
      //  await fetch('https://localhost:7106/api/Product/deleteData?id=4', { method: 'DELETE' });
            
        
    }


    const clearGetOutput = () => {
        setGetResult([]);
        setLoading(true)
    }
    return (
        <div className="assigment">

            <div>
                <div>
                    <button  onClick={getAllData}>Get All</button>

                    {getResult.map(ele =>
                        <div>
                            <table>
                                <tr>
                                    <th>Ürün Adı</th>
                                    <th>Ürün Tipi</th>
                                    <th>Ürün yılı</th>
                                    <th>Kategori İsmi</th>
                                    <th>Kategori Tarifi</th>
                                    <th>Alt Kategori İsmi</th>
                                    <th>Alt Kategori Tarifi</th>

                                </tr>
                                <tr>
                                    <td>{ele.productname}</td>
                                    <td>{ele.producttype}</td>
                                    <td>{ele.productyear}</td>
                                    <td>{ele.categoryname}</td>
                                    <td>{ele.categorydescription}</td>
                                    <td>{ele.subCategoryName}</td>
                                    <td>{ele.subCategoryDescription}</td>
                                </tr>
                             
                            </table>

                          </div>)}
                   

                  
                    <button  onClick={clearGetOutput}>Clear</button>
                </div>
                <div>
                    <input value={value} onChange={(e) => { setValue(e.target.value) }} />
                    <button onClick={deleteRecord}>Delete Record</button>
               </div>


            </div>
        </div>
    );
}
export default App;




