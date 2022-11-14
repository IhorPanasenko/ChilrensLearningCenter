import React from 'react'

import Header from '../../components/headerComponent/Header';
import styles from './Children.css'
import { useState } from 'react';
import { useEffect } from 'react';
import axios from "axios";
import moment from "moment";

function Children() {
    const requesstUrl = 'https://localhost:7296/api/Children'

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
                    <h1>Children</h1>
                    <div className="info_table">
                        <table>
                            <tr>
                                <th>
                                 ChildID
                                </th>
                                <th>
                                    First Name
                                </th>
                                <th>
                                    Second Name
                                </th>
                                <th>
                                    Birthday Date
                                </th>
                                <th>
                                    ClientID
                                </th>
                            </tr>
                            {resp?.map((item) => (
                                <tr key={item.childId}>
                                    <td>
                                        {item.childId}
                                    </td>
                                    <td>
                                        {item.firstName}
                                    </td>
                                    <td>
                                        {item.secondName}
                                    </td>
                                    <td>
                                    {moment(item.birthdayDate).format("DD.MM.YYYY")}
                                    </td>
                                    <td>
                                        {item.clientId}
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

export default Children
