import React from 'react'
import Header from '../../components/headerComponent/Header'

import styles from './Classes.css'
import { useState } from 'react';
import { useEffect } from 'react';
import axios from "axios";
import moment from "moment";

function Classes() {
        const requesstUrl = 'https://localhost:7296/api/Class'

        const [resp, setResp] = useState([]);
        const [isRendered, setIsRendered] = useState(false);
    
        useEffect(() => {
            getData();
        }, [])
    
        async function getData() {
            try {
                const response = await axios({
                    method: "get",
                    url: requesstUrl,
                    data: JSON.stringify(),
                    headers: { "Content-type": "apllication/json; charset=utf-8" }
                }).then((response) => {
                    console.log(response.data);
                    setIsRendered(true);
                    setResp(response.data);
                })
    
            } catch (err) {
                alert(err);
            }
        }
    
        console.log(resp);
        if (isRendered) {
            return (
                <>
                    <Header></Header>
                    <main>
                        <h1>Classes</h1>
                        <div className="info_table">
                            <table>
                                <tr>
                                    <th>
                                     ClassID
                                    </th>
                                    <th>
                                        Day of Week
                                    </th>
                                    <th>
                                        Time
                                    </th>
                                    <th>
                                        SpecialistID
                                    </th>
                                    <th>
                                        ChildID
                                    </th>
                                </tr>
                                {resp?.map((item) => (
                                    <tr key={item.classId}>
                                        <td>
                                            {item.classId}
                                        </td>
                                        <td>
                                            {item.dayOfWeek}
                                        </td>
                                        <td>
                                            {item.time}
                                        </td>
                                        <td>
                                        {item.specialistId}
                                        </td>
                                        <td>
                                            {item.childId}
                                        </td>
                                    </tr>
                                ))}
    
                            </table>
                        </div>
                    </main>
                </>
            )
        }
        else {
            return (
                <div>
                    <h1>Wait... Loading</h1>
                </div>
            )
        }
}

export default Classes
