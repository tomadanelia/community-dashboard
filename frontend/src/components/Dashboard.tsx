import { useEffect, useState } from "react";
import Axios from "axios";
 function Dashboard() {
    
    
    type Event={
        id:number,
        name:string,
        description:string,
        date:string,
    }
    const [events,setEvents]=useState<Event[]>([]);
    useEffect(() => {
        const controller= new AbortController();
        const fetchEvents= async ()=>{
            const response = await Axios.get<Event[]>('http://localhost:3000/events');
            setEvents(response.data);
        }
        fetchEvents();
        return
        ( ) => {
            controller.abort();
        };  
    }, []);
    return (
        <div>
          {events.map((event)=>{
            return(<div key={event.id}>
                <h2>{event.name}</h2>
                <p>{event.description}</p>
                <p>{event.date}</p>
            </div>
            );
          })}
        </div>
    );
}export default Dashboard;