import http from 'k6/http';
import { sleep, check } from 'k6';

// --- Load profile: how much traffic we generate ---
export const options = {
    stages: [
        { duration: "1m", target: 20 },         
        { duration: "1m", target: 20 },
        { duration: "1m", target: 0 }  
    ],
    thresholds: {
 
        http_req_duration: ['p(95)<300'],
        http_req_failed: ["rate==0"],
    },
};

export default function () {
    const baseUrl = __ENV.BASE_URL || 'http://localhost:53135';

    const res = http.get(baseUrl);

    check(res, {
        'status is 200': (r) => r.status === 200,
    });

    // Small think time between requests
    sleep(3);
}